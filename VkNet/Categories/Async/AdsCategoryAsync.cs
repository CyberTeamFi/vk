using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams.Ads;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class AdsCategory
	{
		/// <inheritdoc/>
		public Task<List<bool>> AddOfficeUsersAsync(AdsDataSpecificationParams<UserSpecification> adsDataSpecification)
		{
			return TypeHelper.TryInvokeMethodAsync(() => AddOfficeUsers(adsDataSpecification));
		}

		/// <inheritdoc/>
		public Task<LinkStatus> CheckLinkAsync(CheckLinkParams checkLinkParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CheckLink(checkLinkParams));
		}

		/// <inheritdoc/>
		public Task<List<CreateAdsResult>> CreateAdsAsync(AdsDataSpecificationParams<AdSpecification> adsDataSpecification)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CreateAds(adsDataSpecification));
		}

		/// <inheritdoc/>
		public Task<List<CreateCampaignResult>> CreateCampaignsAsync(AdsDataSpecificationParams<CampaignSpecification> campaignsDataSpecification)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CreateCampaigns(campaignsDataSpecification));
		}

		/// <inheritdoc/>
		public Task<List<CreateClientResult>> CreateClientsAsync(AdsDataSpecificationParams<ClientSpecification> clientDataSpecification)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CreateClients(clientDataSpecification));
		}

		/// <inheritdoc/>
		public Task<CreateLookALikeRequestResult> CreateLookalikeRequestAsync(CreateLookALikeRequestParams createLookALikeRequestParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CreateLookalikeRequest(createLookALikeRequestParams));
		}

		/// <inheritdoc/>
		public Task<CreateTargetGroupResult> CreateTargetGroupAsync(CreateTargetGroupParams createTargetGroupParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CreateTargetGroup(createTargetGroupParams));
		}

		/// <inheritdoc/>
		public Task<CreateTargetPixelResult> CreateTargetPixelAsync(CreateTargetPixelParams createTargetPixelParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CreateTargetPixel(createTargetPixelParams));
		}

		/// <inheritdoc/>
		public Task<List<bool>> DeleteAdsAsync(DeleteAdsParams deleteAdsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DeleteAds(deleteAdsParams));
		}

		/// <inheritdoc/>
		public Task<List<bool>> DeleteCampaignsAsync(DeleteCampaignsParams deleteCampaignsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DeleteCampaigns(deleteCampaignsParams));
		}

		/// <inheritdoc/>
		public Task<List<bool>> DeleteClientsAsync(DeleteClientsParams deleteClientsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DeleteClients(deleteClientsParams));
		}

		/// <inheritdoc/>
		public Task<bool> DeleteTargetGroupAsync(DeleteTargetGroupParams deleteTargetGroupParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DeleteTargetGroup(deleteTargetGroupParams));
		}

		/// <inheritdoc/>
		public Task<bool> DeleteTargetPixelAsync(DeleteTargetPixelParams deleteTargetPixelParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DeleteTargetPixel(deleteTargetPixelParams));
		}

		/// <inheritdoc/>
		public Task<List<AdsAccount>> GetAccountsAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(GetAccounts);
		}

		/// <inheritdoc/>
		public Task<List<Ad>> GetAdsAsync(GetAdsParams getAdsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetAds(getAdsParams));
		}

		/// <inheritdoc/>
		public Task<List<Layout>> GetAdsLayoutAsync(GetAdsLayoutParams getAdsLayoutParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetAdsLayout(getAdsLayoutParams));
		}

		/// <inheritdoc/>
		public Task<List<AdsTargetingResult>> GetAdsTargetingAsync(GetAdsTargetingParams getAdsTargetingParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetAdsTargeting(getAdsTargetingParams));
		}

		/// <inheritdoc/>
		public Task<double> GetBudgetAsync(long accountId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetBudget(accountId));
		}

		/// <inheritdoc/>
		public Task<List<AdsCampaign>> GetCampaignsAsync(AdsGetCampaignsParams adsGetCampaignsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetCampaigns(adsGetCampaignsParams));
		}

		/// <inheritdoc/>
		public Task<GetCategoriesResult> GetCategoriesAsync(Language lang)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetCategories(lang));
		}

		/// <inheritdoc/>
		public Task<List<GetClientsResult>> GetClientsAsync(long accountId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetClients(accountId));
		}

		/// <inheritdoc/>
		public Task<List<GetDemographicsResult>> GetDemographicsAsync(GetDemographicsParams getDemographicsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetDemographics(getDemographicsParams));
		}

		/// <inheritdoc/>
		public Task<GetFloodStatsResult> GetFloodStatsAsync(long accountId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetFloodStats(accountId));
		}

		/// <inheritdoc/>
		public Task<GetLookalikeRequestsResult> GetLookalikeRequestsAsync(GetLookalikeRequestsParams getLookalikeRequestsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetLookalikeRequests(getLookalikeRequestsParams));
		}

		/// <inheritdoc/>
		public Task<List<GetOfficeUsersResult>> GetOfficeUsersAsync(long accountId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetOfficeUsers(accountId));
		}

		/// <inheritdoc/>
		public Task<List<GetPostsReachResult>> GetPostsReachAsync(long accountId, IdsType idsType, string ids)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetPostsReach(accountId, idsType, ids));
		}

		/// <inheritdoc/>
		public Task<GetRejectionReasonResult> GetRejectionReasonAsync(long accountId, long adId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetRejectionReason(accountId, adId));
		}

		/// <inheritdoc/>
		public Task<List<GetStatisticsResult>> GetStatisticsAsync(GetStatisticsParams getStatisticsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetStatistics(getStatisticsParams));
		}

		/// <inheritdoc/>
		public Task<List<GetSuggestionsResult>> GetSuggestionsAsync(GetSuggestionsParams getSuggestionsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetSuggestions(getSuggestionsParams));
		}

		/// <inheritdoc/>
		public Task<List<GetTargetGroupsResult>> GetTargetGroupsAsync(long accountId, long? clientId = null, bool? extended = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetTargetGroups(accountId, clientId, extended));
		}

		/// <inheritdoc/>
		public Task<List<GetTargetPixelsResult>> GetTargetPixelsAsync(long accountId, long? clientId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetTargetPixels(accountId, clientId));
		}

		/// <inheritdoc/>
		public Task<GetTargetingStatsResult> GetTargetingStatsAsync(GetTargetingStatsParams getTargetingStatsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetTargetingStats(getTargetingStatsParams));
		}

		/// <inheritdoc/>
		public Task<Uri> GetUploadUrlAsync(GetUploadUrlParams getUploadUrlParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetUploadUrl(getUploadUrlParams));
		}

		/// <inheritdoc/>
		public Task<Uri> GetVideoUploadUrlAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(GetVideoUploadUrl);
		}

		/// <inheritdoc/>
		public Task<long> ImportTargetContactsAsync(ImportTargetContactsParams importTargetContactsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => ImportTargetContacts(importTargetContactsParams));
		}

		/// <inheritdoc/>
		public Task<List<bool>> RemoveOfficeUsersAsync(RemoveOfficeUsersParams removeOfficeUsersParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => RemoveOfficeUsers(removeOfficeUsersParams));
		}

		/// <inheritdoc/>
		public Task<RemoveTargetContactsResult> RemoveTargetContactsAsync(RemoveTargetContactsParams removeTargetContactsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => RemoveTargetContacts(removeTargetContactsParams));
		}

		/// <inheritdoc/>
		public Task<SaveLookALikeRequestResultResult> SaveLookalikeRequestResultAsync(SaveLookalikeRequestResultParams saveLookalikeRequestResultParams )
		{
			return TypeHelper.TryInvokeMethodAsync(() => SaveLookalikeRequestResult(saveLookalikeRequestResultParams));
		}

		/// <inheritdoc/>
		public Task<ShareTargetGroupResult> ShareTargetGroupAsync(ShareTargetGroupParams shareTargetGroupParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => ShareTargetGroup(shareTargetGroupParams));
		}

		/// <inheritdoc/>
		public Task<List<UpdateAdsResult>> UpdateAdsAsync(AdsDataSpecificationParams<AdEditSpecification> adEditDataSpecification)
		{
			return TypeHelper.TryInvokeMethodAsync(() => UpdateAds(adEditDataSpecification));
		}

		/// <inheritdoc/>
		public Task<List<UpdateCampaignsResult>> UpdateCampaignsAsync(AdsDataSpecificationParams<CampaignModSpecification> campaignModDataSpecification)
		{
			return TypeHelper.TryInvokeMethodAsync(() => UpdateCampaigns(campaignModDataSpecification));
		}

		/// <inheritdoc/>
		public Task<List<UpdateClientsResult>> UpdateClientsAsync(AdsDataSpecificationParams<ClientModSpecification> clientModDataSpecification)
		{
			return TypeHelper.TryInvokeMethodAsync(() => UpdateClients(clientModDataSpecification));
		}

		/// <inheritdoc/>
		public Task<bool> UpdateTargetGroupAsync(UpdateTargetGroupParams updateTargetGroupParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => UpdateTargetGroup(updateTargetGroupParams));
		}

		/// <inheritdoc/>
		public Task<bool> UpdateTargetPixelAsync(UpdateTargetPixelParams updateTargetPixelParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => UpdateTargetPixel(updateTargetPixelParams));
		}

		/// <inheritdoc/>
		public Task<List<GetMusiciansResult>> GetMusiciansAsync(string artistName)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetMusicians(artistName));
		}

		/// <inheritdoc/>
		public Task<List<GetMusiciansByIdsResult>> GetMusiciansByIdsAsync(string ids)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetMusiciansByIds(ids));
		}

		/// <inheritdoc/>
		public Task<List<UpdateOfficeUsersResult>> UpdateOfficeUsersAsync(
			AdsDataSpecificationParams<OfficeUsersSpecification> officeUsersSpecification)
		{
			return TypeHelper.TryInvokeMethodAsync(() => UpdateOfficeUsers(officeUsersSpecification));
		}
	}
}